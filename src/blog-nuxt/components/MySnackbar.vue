<template>
  <div class="text-center ma-2">
    <v-snackbar v-model="snackbar" top :timeout="5000" :color="color">
      {{ text }}
      <v-btn dark text @click="snackbar = false">
        Close
      </v-btn>
    </v-snackbar>
  </div>
</template>
<script>
export default {
  data: () => {
    return {
      snackbar: false,
      text: '',
      color: '',
    }
  },
  methods: {
    showInfo(msg) {
      this.text = msg
      this.color = 'info'
      this.snackbar = true
    },
    showError(msg) {
      this.text = msg
      this.color = 'error'
      this.snackbar = true
    },
    showSuccess(msg) {
      this.text = msg
      this.color = 'success'
      this.snackbar = true
    },
  },
}
</script>
