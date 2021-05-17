<template>
    <div class="searchbar">
     <input type="text" placeholder="Search events..."  v-model="searchQuery"/>
</div>

</template>

<script>
export default {
  
  data() {
    return {

      searchQuery: ""
      
      }

  },



async created() {
      await this.$store.dispatch('fetchEvents');

    }
}
</script>

<style>

</style>