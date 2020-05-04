<template>
  <v-dialog v-model="dialog">
    <v-card>
      <v-card-title>
        {{ title }}
      </v-card-title>
      <v-card-text>
        {{ content }}
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn text color="primary">确认</v-btn>
        <v-btn text>取消</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>
<script>
export default {
  data: () => {
    return {
      dialog: false,
      title: '确认提示',
      content: '您确定要这么做么?',
    }
  },
}
</script>
