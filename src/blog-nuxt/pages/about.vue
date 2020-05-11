<template>
  <v-container>
    <v-card>
      <v-img src="https://api.ixiaowai.cn/api/api.php" max-height="320"></v-img>

      <v-divider></v-divider>
      <v-card-text class="text--primary body-1">
        <h2>关于我</h2>
        <div class="pa-4">
          <p>90后.Net程序员一枚</p>
          <p>三十而立未立，希望不要四十不惑而惑</p>
        </div>
        <h2>博客技术框架</h2>
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
          <p>
            后台主要是用Asp.Net Core 3.1 WebApi + EntityFrameWorkCore
            结合Sqlite实现
          </p>

          <p>
            源码地址：<a
              href="https://github.com/BugChang/BugChang.Blog"
              target="blank"
              >https://github.com/BugChang/BugChang.Blog</a
            >
          </p>
        </div>
        <h2>建站目的</h2>
        <div class="pa-4">
          <p>
            对于亲手搭建一个属于自己的博客一直有一个执念（反反复复做了好几个版本全都不满意）
          </p>
          <p>
            可以把平时遇到的一些开发方面的问题、心得记录下来，分享出去
          </p>
          <p>
            好记性不如烂笔头、写的东西便于日后自己检索
          </p>
          <p>
            锻炼写作能力、并在写作过程中梳理思路更好地理解一些知识点
          </p>
          <p>
            记录生活
          </p>
        </div>

        <h2>更新频率</h2>
        <div class="pa-4">
          <p>
            我这人比较随性、也比较懒，所以基本上更新时间没有固定频率
          </p>
        </div>

        <h2>写些什么</h2>
        <div class="pa-4">
          <p>
            主要以开发相关的只是为主，也会记录一些生活相关的内容
          </p>
          <p>
            可能会有很多网络转载的文章，不过我会标明出处，侵删
          </p>
        </div>

        <h2>联系方式</h2>
        <div class="pa-4">
          <p>QQ：81069681</p>
          <p>微信：CC81069681</p>
          <!-- <img src="/image/wechat.png" width="160" height="160" /> -->
          <p>邮箱：cn.changji@qq.com</p>
        </div>
        <!-- <h2>打赏</h2>
        <div class="pa-4">
          <p>如果觉得网站不错或者内容对你有帮助，赏杯咖啡喝吧</p>
          <div class="d-flex">
            <v-img src="/image/alipay.jpg" width="160"
              ><span>支付宝扫一扫</span>
            </v-img>
            <v-img src="/image/wechatpay.png" width="160">
              <span>微信扫一扫</span></v-img
            >
          </div>
        </div> -->
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
