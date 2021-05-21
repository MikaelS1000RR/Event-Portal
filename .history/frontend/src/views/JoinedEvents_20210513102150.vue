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
  

}


</script>

<style scoped>

</style>