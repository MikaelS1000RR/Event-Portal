<template>
  <div class="myCreated-Events-container">

  </div>
</template>

<script>
import EventItem from "./EventItem.vue";

export default {

  data() {
    return {
      myEvents: [],
    }
  },
  components: {
    EventItem,
  },

  methods: {
    async filterEvents() {

    }
  }


}
</script>

<style scoped>

</style>