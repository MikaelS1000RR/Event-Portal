<template>

<div class="container">

  <div class="gehsdo-logo"> 
  <Searchbar />


<div class="bob">

<EventItem v-for="event of events" :key="event.id" :event="event" />
</div>

    </div>
</div>
      
</template>

<script>
import EventItem from "../components/EventItem.vue";
import Searchbar from "../components/Searchbar.vue";

 

export default {
  
  data() {
    return {


      
      }

  },
  components: {
    EventItem,
    Searchbar
  },

  computed: {
    events(){
    
        return this.$store.state.filteredEventsByLetter; 
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