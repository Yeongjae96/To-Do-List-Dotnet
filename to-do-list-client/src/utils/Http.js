import axios from "axios";
import backendConfig from "@/config/backendConnection";
import store from '@/store'

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

  console.log(convertedUrl);

  return isGet(method) ? getUrlWithData(convertedUrl, data) : convertedUrl;
}

export function request(param) {
  store.commit('popup/MUT_LOADING', true);
  console.log(store);
  return axios({
    url: getUrl(param),
    method: param.method,
    data: param.data,
  });
}

export async function requestAndGetData(param) {
  let result = {};
  try {
    const response = await request(param);
    if (response.status !== 200) throw new Error(response);
    result = response.data;
  } catch(e) {
    console.error(e);
  }
  store.commit('popup/MUT_LOADING', false);
  return result;
}
