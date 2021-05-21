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
      

    }
  },
  components: {
    EventItem,
  },
  computed: {
     events(){
      
       const joinedEvents = this.$store.state.users.filter
        (user => event.hostId === this.$store.state.account.homeAccountIdentifier);

        console.log(joinedEvents);

         return joinedEvents;
     }
  }

}
</script>

<style>

</style>