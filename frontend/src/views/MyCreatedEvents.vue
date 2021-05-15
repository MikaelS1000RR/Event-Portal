<template>

<div class="container">
<v-carousel v-model="model">
    <v-carousel-item
      v-for="(event, i) in events"
      :key="event.id"
    >


     <EventItem2  :key="event.id" :event="event" />

      </v-carousel-item>
  </v-carousel>





 
</div>
      
</template>

<script>
import EventItem2 from "../components/EventItem2.vue";

 

export default {

  data() {
    return {


    }
  },
  components: {
    EventItem2,
  },

  computed: {
     events(){
      
       const myEvents = this.$store.state.allEvents.filter
        (event => event.hostId === this.$store.state.account.homeAccountIdentifier);

        console.log(myEvents);

         return myEvents;
     },
     
    

    
},

async created() {
      await this.$store.dispatch('fetchEvents');
    }
 


}
</script>

<style scoped>

.container {

  height: 100%;
  display: flex;
   align-items: center;
  justify-content: center;


}






  /*background-image: url("../assets/GeshdoT.png"); */

</style>