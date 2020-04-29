<template>
  <v-container fluid class="write-container">
    <v-form class="d-flex flex-column write-form">
      <v-row justify="center">
        <v-col>
          <v-text-field v-model="post.title" label="标题"></v-text-field>
          <v-file-input
            v-show="false"
            id="coverImageInput"
            label="上传封面图"
            @change="uploadCoverImg"
          >
          </v-file-input>
        </v-col>
      </v-row>
      <div ref="mavonEditorDiv" class="mavonEditor">
        <no-ssr>
          <mavon-editor
            ref="mavonEditor"
            v-model="post.content"
            placeholder="请输入正文..."
            :toolbars="markdownOption"
            :style="`height:${editorHeight}px`"
          />
        </no-ssr>
      </div>
      <div>
        <v-row align="center" justify="start">
          <v-switch
            v-model="post.isPublish"
            class="mx-2"
            label="发布"
          ></v-switch>
          <v-switch
            v-model="post.isSticky"
            class="mx-2"
            label="置顶"
          ></v-switch>
          <div style="width: 160px;">
            <v-select
              v-model="post.categoryId"
              :items="categories"
              item-text="name"
              item-value="id"
              label="分类"
              class="mx-2"
            ></v-select>
          </div>
          <v-chip
            v-for="tag in post.tags"
            :key="tag"
            class="mx-2"
            close
            @click:close="removePostTag(tag)"
            >{{ tag }}</v-chip
          >
          <div style="width: 120px;">
            <v-text-field
              v-model="postTagInput.text"
              class="mx-2"
              label="添加标签"
              :error="postTagInput.error"
              :error-messages="postTagInput.errorMsg"
              @keypress.enter="addPostTag"
            ></v-text-field>
          </div>
          <!-- 封面图片管理 Begin -->
          <v-dialog v-model="coverImgDialog" width="40%" max-width="850">
            <template v-slot:activator="{ on }">
              <v-btn class="mx-2" color="primary" v-on="on">
                <v-icon left>mdi-camera</v-icon>
                封面图片</v-btn
              >
            </template>
            <v-card>
              <v-card-title>封面图片管理</v-card-title>
              <v-img
                v-if="post.coverImgUrl"
                :src="post.coverImgUrl"
                max-width="100%"
              >
                <v-btn-toggle class="cover-options" dark>
                  <v-tooltip bottom>
                    <template v-slot:activator="{ on }">
                      <v-btn v-on="on" @click="selectCoverImg">
                        <v-icon>mdi-camera</v-icon>
                      </v-btn>
                    </template>
                    <span>更换</span>
                  </v-tooltip>
                  <v-tooltip bottom>
                    <template v-slot:activator="{ on }">
                      <v-btn v-on="on" @click="clearCoverImg">
                        <v-icon>mdi-delete</v-icon>
                      </v-btn>
                    </template>
                    <span>删除</span>
                  </v-tooltip>
                </v-btn-toggle>
                <v-overlay :value="overlay" absolute>
                  <v-progress-circular
                    indeterminate
                    size="64"
                  ></v-progress-circular>
                </v-overlay>
              </v-img>

              <v-btn
                v-else
                text
                block
                height="80"
                color="primary"
                @click="selectCoverImg"
              >
                <v-icon left>mdi-camera</v-icon>
                上传封面
              </v-btn>
              <v-card-actions>
                <v-btn block text @click="coverImgDialog = false">关闭</v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
          <!-- 封面图片管理 End -->
          <v-spacer></v-spacer>
          <v-btn color="primary" class="mx-2" @click="save">
            <v-icon left>mdi-content-save</v-icon>保存
          </v-btn>
        </v-row>
      </div>
    </v-form>
    <MySnackBar ref="mySnackBar"></MySnackBar>
  </v-container>
</template>
<script>
import MySnackBar from '@/components/MySnackbar'
export default {
  layout: 'admin',
  components: { MySnackBar },
  asyncData({ params }) {
    const postId = params.id
    return { postId }
  },
  data() {
    return {
      coverImgDialog: false,
      editorHeight: 0,
      categories: [],
      overlay: false,
      post: {
        id: 0,
        title: '',
        content: '',
        categoryId: null,
        coverImgUrl: '',
        isPublish: false,
        isSticky: false,
        tags: [],
      },
      postTagInput: {
        text: '',
        error: false,
        errorMsg: '',
      },
      markdownOption: {
        bold: true, // 粗体
      },
    }
  },
  created() {
    this.getCategories()
  },
  mounted() {
    this.calcEditorHeight()
    window.onresize = () => {
      this.calcEditorHeight()
    }
  },
  methods: {
    calcEditorHeight() {
      this.editorHeight = this.$refs.mavonEditorDiv.clientHeight - 20
    },
    async getCategories() {
      try {
        const data = await this.$axios.$get('/categories')
        this.categories = data
      } catch (error) {
        this.$refs.mySnackBar.showError('从服务器获取数据时出现了错误！')
      }
    },
    async save() {
      if (this.post.id > 0) {
        // put
      } else {
        // post
        const data = await this.$axios.$post('/posts', this.post)
        console.log(data)
      }
    },
    addPostTag() {
      const tagText = this.postTagInput.text
      const postTags = this.post.tags
      if (postTags.length >= 5) return
      if (tagText)
        if (!postTags.includes(tagText)) {
          postTags.push(tagText)
        }
      this.clearPostTagInput()
    },
    removePostTag(tag) {
      const index = this.post.tags.indexOf(tag)
      this.post.tags.splice(index, 1)
    },
    clearPostTagInput() {
      this.postTagInput.text = ''
    },
    selectCoverImg() {
      document.getElementById('coverImageInput').click()
    },
    async uploadCoverImg(file) {
      const windowURL = window.URL || window.webkitURL
      this.post.coverImgUrl = windowURL.createObjectURL(file)
      this.overlay = true
      const imgUrl = await this.uploadFile(file)
      this.post.coverImgUrl = imgUrl
      this.overlay = false
    },
    clearCoverImg() {
      this.post.coverImgUrl = ''
    },
    async uploadFile(file) {
      const param = new FormData()
      param.append('formFile', file)
      const { imgUrl } = await this.$axios.$post('/files', param, {
        headers: { 'Content-Type': 'multipart/form-data' },
      })
      return imgUrl
    },
  },
}
</script>

<style scoped>
.mavonEditor {
  width: 100%;
  height: 100%;
}
.mavonEditor > * {
  z-index: 0 !important;
}
.write-container,
.write-form {
  height: 100%;
}
.cover-options {
  position: absolute;
  right: 0;
  bottom: 0;
}
</style>
<style>
.v-application code {
  color: unset !important;
  box-shadow: none !important;
}
</style>
