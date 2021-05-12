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
       return this.$store.state.events.map(event => );
     },
     
     ifHost() {
    if(this.$store.state.account !== undefined && this.$store.state.account.homeAccountIdentifier === this.events.hostId){
      return true
    }
    else{
      return false
    }
  },

    
},

  methods: {
     
  },
 


}
</script>

<style scoped>

</style>