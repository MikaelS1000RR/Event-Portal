<template>

<div class="container">

  <div class="gehsdo-logo" :style="{backgroundImage: `url(${GeshdoT})`}"> 

<div class="bob">

<EventItem v-for="event of events" :key="event.id" :event="event" />
</div>

 

<!-- 
  :style="{backgroundImage: `url(${GeshdoT})`}" 

     <div class="event-list" >
      <EventItem v-for="event of events" :key="event.id" :event="event" />
    </div> 
    
    -->


    </div>
</div>
      
</template>

<script>
import EventItem from "../components/EventItem.vue";
 import GeshdoT from "../assets/GeshdoT.png"

export default {

  data() {
    return {
       GeshdoT,

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

.container {

  height: 100%;
  display: flex;
   align-items: center;
  justify-content: center;


}

.gehsdo-logo {
  height: 50%;
  width: 100%;
  display: flex;
   align-items: center;
  justify-content: center;
  margin-left: 25vw;
  margin-top: 5vw;

}

.bob {
  margin-right: 20vh;
}





  /*background-image: url("../assets/GeshdoT.png"); */

</style>