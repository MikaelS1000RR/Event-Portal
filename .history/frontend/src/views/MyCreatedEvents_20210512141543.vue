<template>
  <div class="myCreated-Events-container">

     <div class="event-list" v-model="ifHost">
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
    if(this.$store.state.account !== undefined && this.$store.state.account.homeAccountIdentifier === this.currEvent.hostId){
      return true
    }
    else{
      return false
    }
    },
    
  },

  methods: {
    async filterEvents() {
       
    }
  },
 


}
</script>

<style scoped>

</style>