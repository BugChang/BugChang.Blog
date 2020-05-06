const cookieparser = process.server ? require('cookieparser') : undefined
export const state = () => ({
  navCategories: [],
  navArchives: [],
  token: null,
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
}

export const actions = {
  async nuxtServerInit({ commit }, { req, $axios }) {
    const categories = await $axios.$get('/categories/nav')
    commit('setNavCategories', categories)

    const archives = await $axios.$get('/archives')
    commit('setNavArchives', archives)

    let token = null
    if (req.headers.cookie) {
      const cookie = cookieparser.parse(req.headers.cookie)
      try {
        token = cookie.token
      } catch (err) {
        // No valid cookie found
      }
    }
    commit('setToken', token)
  },
}
