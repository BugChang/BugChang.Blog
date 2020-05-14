export default function (app) {
  const axios = app.$axios

  // 请求回调
  axios.onRequest((config) => {
    const token = app.store.state.token
    if (token) {
      config.headers.Authorization = `Bearer ${token}`
    }
  })

  // 返回回调
  axios.onResponse((res) => {})

  // 错误回调
  axios.onError((error) => {
    switch (error.response.status) {
      case 401:
        app.router.push('/login')
        break
    }
  })
}
