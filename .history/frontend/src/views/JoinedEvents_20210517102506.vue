<template>
  <div class="joined-events-container">

      
    <div class="event-list">
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
      
      let myEvents = this.$store.state.allEvents.filter
      (event => event.hostId === this.$store.state.account.homeAccountIdentifier);

      console.log(myEvents);

      if(this.searchQuery !== "") {
        
        myEvents =  myEvents.filter
        (event => event.name.toLowerCase().includes(this.searchQuery.toLowerCase()));
    
            console.log(myEvents);
        } 
        
       
          return myEvents;
     },
    
},


    computed: {

       events() {


       
         const joinedEvents = this.$store.state.allEvents.filter 
        (event => event.joinedUsers.includes(this.$store.state.account.name));

        console.log(joinedEvents);

          return joinedEvents;

      }
    },

    async created() {
      await this.$store.dispatch('fetchEvents');
    }

  


  

  }


</script>

<style scoped>

</style>