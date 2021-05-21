module.exports = {
  transpileDependencies: ["vuetify"],

  devServer: {
    proxy: "https://localhost:8001",
  },
};
