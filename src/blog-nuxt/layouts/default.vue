<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <!-- <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon> -->
      <v-toolbar-title>BugChang's Blog</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-toolbar-items>
        <v-btn text to="/"> 首 页</v-btn>
        <v-btn text to="/category"> 分 类</v-btn>
        <v-btn text to="/tags">标 签</v-btn>
        <v-btn text to="/about">关 于</v-btn>
        <v-btn text to="/contact">联 系</v-btn>
      </v-toolbar-items>
    </v-app-bar>
    <!-- <LeftDrawer :drawer="drawer"></LeftDrawer> -->
    <v-content class="grey lighten-3">
      <nuxt class="pa-2"></nuxt>
    </v-content>
    <v-footer app>
      <div class="text-center" style="width: 100%;">
        &copy; CopyRight 2019- {{ new Date().getFullYear() }} BugChang.COM Inc.
        All Rights Reserved. 辽ICP备19020610号-1
      </div>
    </v-footer>
  </v-app>
</template>

<script>
// import LeftDrawer from '@/components/LeftDrawer'
export default {
  // components: { LeftDrawer },
  data() {
    return {
      drawer: false,
    }
  },
}
</script>
