<template>
  <div class="myCreated-Events-container">

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
      myEvents: [],

    }
  },
  components: {
    EventItem,
  },

  computed: {
     events(){
       return this.$store.state.events;
     },
      currEvent() {
      return this.$store.state.specEvent;
    },
    hostUser() {
      return this.$store.state.specEvent.hostName;
    },
    id() {
      return this.$route.params.id;
    },

    ifHost() {
      if(this.currEvent.hostId == this.events) {
        return true
      }
    }
    
  },

  methods: {
    async filterEvents() {
       
    }
  },
 


}
</script>

<style scoped>

</style>