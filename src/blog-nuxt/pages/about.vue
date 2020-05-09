<template>
  <v-container>
    <v-card>
      <v-img src="https://api.ixiaowai.cn/api/api.php" max-height="320"></v-img>
      <v-card-title>
        <h1>关于</h1>
      </v-card-title>
      <v-divider></v-divider>
      <v-card-text class="text--primary body-1">
        <h2>关于我</h2>
        <div class="pa-4">
          <p>90后.Net程序员，怨天尤人、不务正业、游手好闲。</p>
        </div>
        <h2>技术框架</h2>
        <div class="pa-4">
          <p>
            前台使用<a href="https://zh.nuxtjs.org/" target="blank">Nuxt.js</a
            >服务端渲染（SSR）框架结合<a
              href="https://vuetifyjs.com/zh-Hans/"
              target="blank"
              >Vuetify</a
            >
            UI框架搭建
          </p>
          <p>后台主要是用.Net Core 3.1 WebApi结合Sqlite实现</p>
          <p>部署在CentOS-7 的Nginx上</p>
          <p>
            源码地址：<a
              href="https://github.com/BugChang/BugChang.Blog"
              target="blank"
              >https://github.com/BugChang/BugChang.Blog</a
            >
          </p>
        </div>
        <h2>联系方式</h2>
        <div class="pa-4">
          <p>QQ：81069681</p>
          <p>微信：CC81069681</p>
          <!-- <img src="/image/wechat.png" width="160" height="160" /> -->
          <p>邮箱：cn.changji@qq.com</p>
        </div>
        <h2>打赏</h2>
        <div class="pa-4">
          <p>赏杯咖啡</p>
          <img src="/image/wechat.png" width="160" height="160" />
          <img src="/image/wechat.png" width="160" height="160" />
          <img src="/image/wechat.png" width="160" height="160" />
        </div>
      </v-card-text>
    </v-card>
  </v-container>
</template>
<script>
export default {
  head() {
    return {
      title: '关于',
      meta: [
        {
          hid: 'description',
          name: 'description',
          content:
            "BugChang's Blog,个人博客,前后端分离博客,nuxt博客,.net core博客,BugChang的博客,BugChang,博客",
        },
      ],
    }
  },
}
</script>
