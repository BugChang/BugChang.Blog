// 身份验证
export default function ({ store, redirect, route }) {
  // If the user is not authenticated
  if (!store.state.token) {
    return redirect('/login?returnUrl=' + route.path)
  }
}
