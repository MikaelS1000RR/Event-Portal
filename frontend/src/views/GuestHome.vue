<template>
  <div class="guest-home">
    <div class="event-list-wrapper">
     <EventList/>
     
    </div>
  </div>
</template>

<script>
import EventList from '../components/EventList.vue'

export default {
  name: 'GuestHome',
  components: {
   EventList
  },


 

  methods: {
   

  },
};
</script>

<style scoped>
</style>
