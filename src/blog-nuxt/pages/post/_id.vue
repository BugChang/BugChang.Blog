<style>
.markdown-body {
  box-sizing: border-box;
  min-width: 200px;
  max-width: 980px;
  margin: 0 auto;
  padding: 0 15px;
}

@media (max-width: 767px) {
  .markdown-body {
    padding: 15px;
  }
}
.article-head {
  width: 100%;
  position: absolute;
  bottom: 0;
  left: 0;
  background: rgba(0, 0, 0, 0.6);
}
.article-head a {
  text-decoration: none;
}
.article-head-primary {
  color: white;
  padding: 24px 16px 16px 16px;
}
.article-head-primary-title {
  opacity: 1;
  display: block;
  font-size: 28px;
  line-height: 36px;
}

.article-head-primary-subtitle {
  opacity: 0.7;
  display: block;
  font-size: 14px;
  line-height: 24px;
}
.v-application code {
  color: currentColor !important;
  box-shadow: none !important;
}
</style>
<template>
  <v-container style="max-width: 1050px;">
    <v-card>
      <v-img
        :src="
          post.coverImgUrl || 'https://api.ixiaowai.cn/api/api.php?t=' + post.id
        "
      >
        <div class="article-head">
          <div class="article-head-primary">
            <div class="article-head-primary-title">
              {{ post.title }}
            </div>
            <div class="article-head-primary-subtitle">
              <v-icon color="white" small>
                mdi-calendar-month
              </v-icon>
              {{ post.createTime }}
            </div>
          </div>
        </div>
      </v-img>
      <v-card-title>
        <v-btn
          text
          :color="post.categoryColor"
          @click="gotoCategory(post.categoryId)"
        >
          <v-icon>mdi-folder</v-icon>
          {{ post.categoryName }}
        </v-btn>
        <v-chip
          v-for="tag in post.tags"
          :key="tag"
          outlined
          small
          class="mx-1"
          :to="`/tag/${tag}`"
        >
          <v-icon small>
            mdi-tag
          </v-icon>
          {{ tag }}
        </v-chip>
      </v-card-title>
      <!-- eslint-disable-next-line vue/no-v-html -->
      <div class="markdown-body" v-html="post.htmlContent" />
      <v-card-actions>
        <v-spacer />
        <Share :title="post.title" :post-id="post.id"></Share>
      </v-card-actions>
    </v-card>
    <Comment class="mt-4" :post-id="post.id"></Comment>
  </v-container>
</template>
<script>
import 'github-markdown-css/github-markdown.css'
import Comment from '@/components/Comment'
import Share from '@/components/Share'
export default {
  components: { Comment, Share },
  async asyncData({ $axios, params, error }) {
    try {
      const post = await $axios.$get(`/posts/${params.id}/fullcontent`)
      return { post }
    } catch (e) {
      error({
        statusCode: e.response.status,
        message: e.response.data.error,
        customMessage: true,
      })
    }
  },
  data: () => ({
    comment: {
      content: '评论功能暂未开放...',
    },
  }),
  mounted() {
    this.wxShare(
      {
        title: this.post.title,
        desc: "BugChang's Blog",
        link: location.href,
        imgUrl: location.protocol + '//' + location.host + '/favicon.ico',
      },
      location.href
    )
    this.initHljs()
  },
  created() {},
  methods: {
    initHljs() {
      const vm = this
      setTimeout(() => {
        if (!window.hljs) {
          vm.initHljs()
        } else {
          document.querySelectorAll('pre code').forEach((block) => {
            window.hljs.highlightBlock(block)
          })
        }
      }, 200)
    },
  },
  head() {
    return {
      title: this.post.title,
      script: [
        {
          src:
            'https://cdnjs.cloudflare.com/ajax/libs/highlight.js/9.18.1/highlight.min.js',
        },
      ],
      link: [
        {
          rel: 'stylesheet',
          href:
            'https://cdnjs.cloudflare.com/ajax/libs/highlight.js/9.18.1/styles/github.min.css',
        },
      ],
    }
  },
}
</script>
