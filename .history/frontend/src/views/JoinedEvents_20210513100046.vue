<template>
  <div class="joined-events-container">

<div class="event-list" >
      <EventItem v-for="event of joinedEvents" :key="event.id" :event="event" />
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
 created() {
      

 this.$store.dispatch('fetchEvents');

    },

    computed: {

      async joinedEvents() {


       
      await const bob= this.$store.state.events.filter 
        (event => event.joinedUsers.includes(this.$store.state.account.name));

        console.log(joinedEvents);

          return 



    }
    }
  }


</script>

<style scoped>

</style>