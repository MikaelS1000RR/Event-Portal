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
      

    }
  },
  components: {
    EventItem,
  },

  computed: {
     events(){
       return 
       const something = this.$store.state.events.map 
        (event => event.hostId === this.$store.state.account.homeAccountIdentifier);
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