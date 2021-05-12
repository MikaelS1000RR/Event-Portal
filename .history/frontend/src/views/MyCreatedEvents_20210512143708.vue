<template>
  <div class="myCreated-Events-container">

     <div class="event-list" >
      <EventItem v-model="ifHost" v-for="event of events" :key="event.id" :event="event" />
    </div>

  </div>
</template>

<script>
import EventItem from "../components/EventItem.vue";

export default {
props: ["event"],
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
     
    

     ifHost() {
    if(this.$store.state.account !== undefined && this.$store.state.account.homeAccountIdentifier === this.event.hostId){
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