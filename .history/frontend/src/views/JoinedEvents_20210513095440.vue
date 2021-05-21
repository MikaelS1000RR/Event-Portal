<template>
  <div class="joined-events-container">

<div class="event-list" >
      <EventItem v-for="event of events" :key="event.id" :event="event" />
    </div>


  </div>
</template>

<script>
import EventItem from "../components/EventItem.vue";

export default {

 data() {
   
    return {
      joinedEvents: []

    }
  },
  components: {
    EventItem,
  },
  async created() {
      
       const joinedEvents = 
       
       await this.$store.state.events.filter 
        (event => event.joinedUsers.includes(this.$store.state.account.name));

        console.log(joinedEvents);

         return joinedEvents;
    
    }
  }


</script>

<style scoped>

</style>