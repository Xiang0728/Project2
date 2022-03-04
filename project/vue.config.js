module.exports = {
  publicPath: process.env.NODE_ENV === 'production'  ? '' : '',
  devServer: {
    proxy: "https://localhost:44370",
  },
  transpileDependencies: [
    'vuetify'
  ]
}
