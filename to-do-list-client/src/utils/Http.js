import axios from "axios";
import backendConfig from "@/config/backendConnection";
import store from "@/store";

axios.defaults.baseURL = backendConfig.host;
// axios.defaults.

const isGet = (method) => method.toLowerCase() === "get";
const getUrlWithData = (url, data) =>
  data
    ? Object.keys(data).reduce(
        (prev, cur, idx) =>
          idx === 0
            ? `${prev}?${cur}=${data[cur]}`
            : `${prev}&${cur}=${data[cur]}`,
        url
      )
    : url;

function getUrl({ url, method, data, version = "v1" }) {
  const apiStringIndex = url.indexOf("/api") + "/api".length;
  let convertedUrl =
    apiStringIndex > 3
      ? `${url.substring(0, apiStringIndex)}/${version}${url.substring(
          apiStringIndex
        )}`
      : `/api/${version}${url.startsWith("/") ? url : "/" + url}`;
  convertedUrl = convertedUrl.replace(/{(.*)}/g, (a, g1) => {
    return data[g1];
  });
  return isGet(method) ? getUrlWithData(convertedUrl, data) : convertedUrl;
}

const loadingApi = (() => {
  let id = 0;
  return {
    apiCallMap: new Map(),
    getApiID: () => id++,
    wrappingFunc: async (func, params) => {
      const apiID = loadingApi.getApiID();
      let result = null;
      try {
        loadingApi.apiCallMap.set(apiID, false);
        result = await func.call(func, params);
      } catch (e) {
        console.error(e);
      } finally {
        loadingApi.apiCallMap.delete(apiID);
      }

      if (!loadingApi.apiCallMap.size) {
        store.commit("popup/MUT_LOADING", false);
      }

      return result;
    },
  };
})();

export function request(param) {
  store.commit("popup/MUT_LOADING", true);
  // const longlongFunction = async () => {
  //   return { status: 200, data: { text: "hi" } };
  // };
  // console.log(param, getUrl(param));

  // return new Promise((resolve) => {
  //   setTimeout(
  //     () => {
  //       const response = longlongFunction();
  //       console.log(param.immedate);
  //       resolve(response);
  //     },
  //     param.immediate ? 0 : 1000
  //   );
  // });
  return axios({
    url: getUrl(param),
    method: param.method,
    data: param.data,
  });
}
export async function requestAndGetData(param) {
  let result = {};
  try {
    const response = await loadingApi.wrappingFunc(request, param);
    // const response = await request(param);
    if (response.status !== 200) throw new Error(response);
    result = response.data;
  } catch (e) {
    console.error(e);
  }
  return result;
}
