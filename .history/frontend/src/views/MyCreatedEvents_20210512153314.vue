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
      
       const myEvents = this.$store.state.events.filter
        (event => event.hostId === this.$store.state.account.homeAccountIdentifier);

        console.log(something);

         return something;
     },
     
    

    
},

  methods: {
     
  },
 


}
</script>

<style scoped>

</style>