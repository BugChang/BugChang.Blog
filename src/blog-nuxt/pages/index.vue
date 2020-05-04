<style scoped>
.container {
  max-width: 1050px;
  margin: 0 auto;
}
</style>
<template>
  <v-container>
    <v-row style="margin-bottom: 70px;">
      <v-col cols="12">
        <v-carousel cycle hide-delimiter-background show-arrows-on-hover>
          <v-carousel-item v-for="(slide, i) in slides" :key="i">
            <v-img :src="'https://api.ixiaowai.cn/api/api.php'" height="100%">
              <v-row class="fill-height" align="end" justify="center">
                <v-card
                  class="display-1 white--text py-2 text-center"
                  style="opacity: 0.5;"
                  width="100%"
                  height="120px"
                >
                  {{ slide }}
                </v-card>
              </v-row>
            </v-img>
          </v-carousel-item>
        </v-carousel>
      </v-col>
    </v-row>
    <div class="d-flex justify-space-between flex-wrap">
      <PostPreview
        v-for="post in posts"
        :key="post.id"
        :post="post"
        class="mb-4 align-self-center"
        style="width: 100%;"
      />
    </div>
  </v-container>
</template>
<script>
import PostPreview from '@/components/PostPreview'
export default {
  components: {
    PostPreview,
  },
  async asyncData({ $axios }) {
    const data = await $axios.$get('/posts/homelist')
    return { posts: data.records }
  },
  data() {
    return {
      toggle_exclusive: undefined,
      items: [
        {
          src: 'https://api.ixiaowai.cn/api/api.php?1',
        },
        {
          src: 'https://api.ixiaowai.cn/api/api.php?2',
        },
        {
          src: 'https://api.ixiaowai.cn/api/api.php?3',
        },
        {
          src: 'https://api.ixiaowai.cn/api/api.php?4',
        },
      ],
      colors: ['indigo', 'warning', 'pink darken-2', 'red lighten-1'],
      slides: ['轮播即将上线', 'Carousel about on-line'],
    }
  },
  created() {},
  head() {
    return {
      title: '首页',
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
