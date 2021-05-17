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
}
</script>

<style>

</style>