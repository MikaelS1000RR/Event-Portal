<template>
  <div class="myCreated-Events-container">

  </div>
</template>

<script>
import EventItem from ".components";

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