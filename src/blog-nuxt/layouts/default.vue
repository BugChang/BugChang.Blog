<template>
  <v-app>
    <v-app-bar app color="primary" dark clipped-left>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      <v-toolbar-title>BugChang's Blog</v-toolbar-title>
      <v-spacer></v-spacer>
      <!-- <v-toolbar-items>
        <v-btn text to="/"> <v-icon left>mdi-home</v-icon>首 页</v-btn>
        <v-btn text to="/category"><v-icon left>mdi-apps</v-icon>分 类</v-btn>
        <v-btn text to="/tags"
          ><v-icon left>mdi-tag-multiple</v-icon>标 签</v-btn
        >
        <v-btn text to="/about"
          ><v-icon left>mdi-information</v-icon>关 于</v-btn
        >
        <v-btn text to="/contact"><v-icon left>mdi-phone</v-icon>联 系</v-btn>
      </v-toolbar-items> -->
    </v-app-bar>
    <LeftNavBar :drawer="drawer"></LeftNavBar>
    <v-content v-scroll="onScroll" class="grey lighten-3">
      <nuxt class="pa-2"></nuxt>
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
export default {
  components: { LeftNavBar },

  data() {
    return {
      drawer: false,
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
