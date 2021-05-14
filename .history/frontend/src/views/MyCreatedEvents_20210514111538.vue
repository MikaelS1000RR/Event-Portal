<template>

  <div class="bob">

  

  <div class="myCreated-Events-container" >

<!-- :style="{backgroundImage: `url(${GeshdoT})`}" -->
     <div class="event-list" >
      <EventItem v-for="event of events" :key="event.id" :event="event" />
    </div>

  

  </div>
    </div>
      
</template>

<script>
import EventItem from "../components/EventItem.vue";
// import GeshdoT from "../assets/GeshdoT.png"

export default {

  data() {
    return {
      // GeshdoT,

    }
  },
  components: {
    EventItem,
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
.myCreated-Events-container {
 display: flex;
  align-items: center;
  justify-content: center;

}

.bob {

  height: 100%;
  display: flex;
   align-items: center;
  justify-content: center;
  background-image: url("../assets/GeshdoT.png");

}



  /*background-image: url("../assets/GeshdoT.png"); */

</style>