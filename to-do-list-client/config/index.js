const hostMap = {
  local: "http://localhost:9999",
  "local-out": "http://homedev.o-r.kr:8080",
};

module.exports = {
  port: 8080,
  backendUrl: hostMap[process.env.VUE_APP_HOST_KEY],
};
