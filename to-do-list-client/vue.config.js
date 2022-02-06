module.exports = {
  devServer: {
    disableHostCheck: true,
    port: process.env.VUE_APP_PORT || 5000,
    proxy: {
      "^/api": {
        target: "http://homedev.o-r.kr:8080",
      },
    },
  },
  configureWebpack: {
    devtool: "source-map",
  },
};
