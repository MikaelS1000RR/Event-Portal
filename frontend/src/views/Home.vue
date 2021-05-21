<template>
  <div class="home">
    <div class="event-list-wrapper">
     <EventList/>
     
    </div>
  </div>
</template>

<script>
import EventList from '../components/EventList.vue'

export default {
  name: 'Home',
  components: {
   EventList
  },


 

  methods: {
   

  },
};
</script>

<style scoped>
</style>
