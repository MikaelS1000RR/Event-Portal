<template>
  <v-overlay :value="loadingContent" color="rgba(0, 0, 0, 1)" >
    <v-progress-circular indeterminate size="64"></v-progress-circular>
  </v-overlay>
</template>

<script>
export default {
  computed: {
  

    loadingContent() {
      return this.$store.state.loading;
    },
  },
};
</script>

<style></style>
