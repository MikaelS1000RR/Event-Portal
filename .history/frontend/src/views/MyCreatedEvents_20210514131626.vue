<template>

<div class="container">

<EventItem v-for="event of events" :key="event.id" :event="event" />
  <div class="gehsdo-logo" :style="{backgroundImage: `url(${GeshdoT})`}"> 

<div class="bob">

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
  margin-left: 40vh;


}

.gehsdo-logo {
  height: 70%;
  width: 80%;
  display: flex;
   align-items: center;
  justify-content: center;
  margin-left: 10vw;

  background-size: 90%;

   -webkit-transform: rotate(90deg); /* Safari and Chrome */
    -moz-transform: rotate(90deg);   /* Firefox */
    -ms-transform: rotate(90deg);   /* IE 9 */
    -o-transform: rotate(90deg);   /* Opera */
    transform: rotate(90deg);

}

.bob {
  margin-right: 20vh;
}





  /*background-image: url("../assets/GeshdoT.png"); */

</style>