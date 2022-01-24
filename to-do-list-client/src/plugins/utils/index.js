const getExportValues = (requireContextValue)  => requireContextValue.default || requireContextValue;
const getModuleName = (filePath) => filePath
    .replace(/^\.\//, '') // 파일 경로 앞단의 ./ 제거
    .replace(/\.js$/, '') // .js 제거

const requireContext = require.context(
    '@/utils', // 탐색할 root 폴더
    true, // 하위 폴더까지 탐색
    /.*.js$/ // 탐색할 정규 표현식 (index를 제외한 js 파일들을 탐색합니다)
);

const utilModuleMap = {}; 

requireContext.keys().some(item => {
  const moduleName = getModuleName(item);
  const moduleInfo = getExportValues(requireContext(item));
  
  const isRegist = moduleInfo.isAutoRegist === undefined ? true :  moduleInfo.isAutoRegist;
  if (!isRegist) return false;
  Object.assign(utilModuleMap, { [moduleName]: moduleInfo })
  return false;
});
console.log(utilModuleMap);

export default {
  install: (app) => {
    Object.keys(utilModuleMap).forEach(moduleName => {
      app.config.globalProperties[`$${moduleName}`] = utilModuleMap[moduleName]; 
    });
    // app.config.globalProperties.$moment = moment; 
  }
}