const cookieparser = process.server ? require('cookieparser') : undefined
export const state = () => ({
  navCategories: [],
  navArchives: [],
  token: null,
  currentUser: {},
})

export const mutations = {
  setNavCategories(state, categories) {
    state.navCategories = categories
  },
  setNavArchives(state, archives) {
    state.navArchives = archives
  },
  setToken(state, token) {
    state.token = token
  },
  setUserInfo(state, currentUser) {
    state.currentUser = currentUser
  },
}

export const actions = {
  async nuxtServerInit({ commit }, { req, $axios }) {
    const categories = await $axios.$get('/categories/nav')
    commit('setNavCategories', categories)

    const archives = await $axios.$get('/archives')
    commit('setNavArchives', archives)

    let token = null
    let currentUser = null
    if (req.headers.cookie) {
      const cookie = cookieparser.parse(req.headers.cookie)
      try {
        token = cookie.token
        currentUser = JSON.parse(cookie.currentUser)
      } catch (err) {
        // No valid cookie found
      }
    }
    commit('setToken', token)
    commit('setUserInfo', currentUser)
  },
}
