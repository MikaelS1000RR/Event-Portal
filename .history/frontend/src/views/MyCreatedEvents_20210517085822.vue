<template>

<div class="container">

  <div class="gehsdo-logo"> 

   <div class="searchbar">
     <input type="text" placeholder="Search events..."  v-model="s"/>
   </div>

<div class="bob">

<EventItem v-for="event of events" :key="event.id" :event="event" />
</div>

    </div>
</div>
      
</template>

<script>
import EventItem from "../components/EventItem.vue";

 

export default {

  data() {
    return {

    }
const searchQuery = ref("");

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
  width: 70%;
  display: flex;
   align-items: center;
  justify-content: center;
  margin-left: 10vw;


  background-size: 90%;

  

}

.bob {
  margin-right: 20vh;
}





  /*background-image: url("../assets/GeshdoT.png"); */

</style>