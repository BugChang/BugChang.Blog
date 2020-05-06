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
        <v-btn icon color="primary">
          <v-icon>mdi-share-variant</v-icon>
        </v-btn>
      </v-card-actions>
    </v-card>
    <v-card class="mt-4">
      <v-card-title>评论列表</v-card-title>
      <v-card-text>
        <div id="disqus_thread"></div>
        <script>
          /**
           *  RECOMMENDED CONFIGURATION VARIABLES: EDIT AND UNCOMMENT THE SECTION BELOW TO INSERT DYNAMIC VALUES FROM YOUR PLATFORM OR CMS.
           *  LEARN WHY DEFINING THESE VARIABLES IS IMPORTANT: https://disqus.com/admin/universalcode/#configuration-variables*/
          /*
var disqus_config = function () {
this.page.url = PAGE_URL;  // Replace PAGE_URL with your page's canonical URL variable
this.page.identifier = PAGE_IDENTIFIER; // Replace PAGE_IDENTIFIER with your page's unique identifier variable
};
*/
          ;(function () {
            // DON'T EDIT BELOW THIS LINE
            var d = document,
              s = d.createElement('script')
            s.src = 'https://bugchang-blog.disqus.com/embed.js'
            s.setAttribute('data-timestamp', +new Date())
            ;(d.head || d.body).appendChild(s)
          })()
        </script>
        <noscript
          >Please enable JavaScript to view the
          <a href="https://disqus.com/?ref_noscript"
            >comments powered by Disqus.</a
          ></noscript
        >
      </v-card-text>
    </v-card>
  </v-container>
</template>
<script>
import 'github-markdown-css/github-markdown.css'
export default {
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
    this.initHljs()
    // window.hljs.initHighlightingOnLoad()
  },
  created() {},
  methods: {
    initHljs() {
      const func = setTimeout(() => {
        if (!window.hljs) {
          func()
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
