<template>
  <div class="myCreated-Events-container" >

<!-- :style="{backgroundImage: `url(${GeshdoT})`}" -->
     <div class="event-list" >
      <EventItem v-for="event of events" :key="event.id" :event="event" />
    </div>

  </div>
</template>

<script>
import EventItem from "../components/EventItem.vue";
import GeshdoT from "../assets/GeshdoT.png"

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
   display: grid;
  grid-column-gap: 50px;
  grid-template-columns: auto auto auto;
  background-color: #2196F3;
  padding: 10px;
}
.event-list {
  background-color: rgba(255, 255, 255, 0.8);
  border: 1px solid rgba(0, 0, 0, 0.8);
  padding: 20px;
  font-size: 30px;
  text-align: center;
}
  /*background-image: url("../assets/GeshdoT.png"); */

</style>