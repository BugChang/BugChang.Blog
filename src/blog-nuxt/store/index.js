// const cookieparser = process.server ? require('cookieparser') : undefined
export const state = () => ({
  navCategories: [],
  navArchives: [],
})

export const mutations = {
  setNavCategories(state, categories) {
    state.navCategories = categories
  },
  setNavArchives(state, archives) {
    state.navArchives = archives
  },
}

export const actions = {
  async nuxtServerInit({ commit }, { req, $axios }) {
    try {
      const categories = await $axios.$get('/categories/nav')
      commit('setNavCategories', categories)
    } catch (error) {}

    try {
      const archives = await $axios.$get('/archives')
      commit('setNavArchives', archives)
    } catch (error) {}
  },
}
