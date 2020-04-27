<template>
  <v-container fluid class="write-container">
    <v-form class="d-flex flex-column write-form">
      <v-text-field label="标题"></v-text-field>
      <div ref="mavonEditorDiv" class="mavonEditor">
        <no-ssr>
          <mavon-editor
            ref="mavonEditor"
            v-model="handbook"
            :toolbars="markdownOption"
            :style="`height:${editorHeight}px`"
          />
        </no-ssr>
      </div>
      <div class="mt-2">
        <v-btn color="primary">发布</v-btn>
        <v-btn color="primary">保存草稿</v-btn>
      </div>
    </v-form>
  </v-container>
</template>
<script>
export default {
  layout: 'admin',
  data() {
    return {
      editorHeight: 0,
      markdownOption: {
        bold: true, // 粗体
      },
      handbook: '#### how to use mavonEditor in nuxt.js',
    }
  },
  mounted() {
    this.calcEditorHeight()
    window.onresize = () => {
      this.calcEditorHeight()
    }
  },
  methods: {
    calcEditorHeight() {
      console.log(1)
      this.editorHeight = this.$refs.mavonEditorDiv.clientHeight
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
</style>
<style>
.v-application code {
  color: unset !important;
  box-shadow: none !important;
}
</style>
