<style scoped>
.container {
  max-width: 1050px;
  margin: 0 auto;
}
</style>
<template>
  <v-container>
    <div class="d-flex justify-space-between flex-wrap">
      <PostPreview
        v-for="post in posts"
        :key="post.id"
        :post="post"
        class="mb-4 align-self-center"
        style="width: 100%;"
      />
    </div>
    <div class="text-center">
      <v-pagination
        v-model="page"
        :length="pageCount"
        @input="jump"
      ></v-pagination>
    </div>
  </v-container>
</template>
<script>
import PostPreview from '@/components/PostPreview'
export default {
  validate({ params }) {
    // 必须是number类型
    return /^\d+$/.test(params.page)
  },
  components: {
    PostPreview,
  },
  async asyncData({ $axios, params }) {
    const currentPage = params.page ?? 1
    const data = await $axios.$get(`/posts/homelist?page=${currentPage}`)
    return { posts: data.records, page: data.page, pageCount: data.pageCount }
  },
  data() {
    return {}
  },
  created() {},
  methods: {
    jump(page) {
      if (page === 1) {
        this.$router.push(`/`)
      } else {
        this.$router.push(`/page/${page}`)
      }
    },
  },
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
