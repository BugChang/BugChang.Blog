<style scoped>
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
</style>
<template>
  <v-hover v-slot:default="{ hover }">
    <v-card :elevation="hover ? 8 : 2">
      <nuxt-link :to="`/post/${post.id}`">
        <v-img
          v-ripple
          :src="
            post.coverImgUrl ||
            'https://api.ixiaowai.cn/api/api.php?t=' + post.id
          "
          height="280px"
        >
          <template v-slot:placeholder>
            <Loading></Loading>
          </template>
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
      </nuxt-link>
      <v-card-title class="pl-0">
        <v-btn
          :to="`/category/${post.categoryId}`"
          exact
          exact-active-class="btn-category"
          active-class="btn-category"
          text
          :color="post.categoryColor"
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

      <v-card-text>{{ post.summary }}</v-card-text>
      <v-card-actions>
        <v-btn text color="primary" :to="'/post/' + post.id">
          Read More({{ post.viewCount }})
        </v-btn>
        <v-spacer />
        <Share :title="post.title" :post-id="post.id"></Share>
      </v-card-actions>
    </v-card>
  </v-hover>
</template>
<script>
import Loading from '@/components/Loading'
import Share from '@/components/Share'
export default {
  components: { Loading, Share },
  props: {
    post: {
      type: Object,
      default() {
        return {}
      },
    },
  },
  data() {
    return {
      isActive: false,
    }
  },
  methods: {
    gotoCategory(categoryId) {
      this.$router.push(`/category/${categoryId}`)
    },
  },
}
</script>
<style scoped>
.btn-category:hover::before,
.btn-category::before {
  opacity: 0;
}

/* .theme--light.v-btn--active:hover::before,
.theme--light.v-btn--active::before {
  opacity: 0;
} */
</style>
