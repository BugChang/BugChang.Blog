<style scoped>
.container {
  max-width: 1050px;
  margin: 0 auto;
}
</style>

<template>
  <v-app>
    <v-app-bar app color="primary" dark clipped-left>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      <v-toolbar-title>BugChang's Blog</v-toolbar-title>
      <v-spacer></v-spacer>

      <AccountInfo></AccountInfo>
    </v-app-bar>
    <v-navigation-drawer v-model="drawer" width="300" app clipped>
      <LeftNavBar></LeftNavBar>
    </v-navigation-drawer>

    <v-content v-scroll="onScroll" class="grey lighten-3">
      <nuxt></nuxt>
      <v-btn
        v-if="gotoTopVisible"
        fixed
        dark
        fab
        bottom
        right
        color="primary"
        @click="$vuetify.goTo(0)"
      >
        <v-icon>mdi-arrow-up</v-icon>
      </v-btn>
    </v-content>
    <v-footer>
      <div class="text-center" style="width: 100%;">
        &copy; CopyRight 2019- {{ new Date().getFullYear() }} BugChang.COM Inc.
        All Rights Reserved. 辽ICP备19020610号-1
      </div>
    </v-footer>
  </v-app>
</template>

<script>
import LeftNavBar from '@/components/LeftNavBar'
import AccountInfo from '@/components/AccountInfo'
export default {
  components: { LeftNavBar, AccountInfo },

  data() {
    return {
      drawer: null,
      gotoTopVisible: false,
    }
  },
  methods: {
    onScroll() {
      this.gotoTopVisible = window.scrollY > 50
    },
  },
}
</script>
