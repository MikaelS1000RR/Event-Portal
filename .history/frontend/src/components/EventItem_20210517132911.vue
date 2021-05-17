<template>
  <div class="event-card" @click="redirect">
    <v-card :loading="loading" class="mx-auto my-12" max-width="375">

      <div class="access">
        <p>{{event.access.charAt(0).toUpperCase() + event.access.slice(1)}}</p>


       
      </div>
      <v-img class="event-img" height="200px" :src="event.imgUrl">
      
        <v-card-title>
          <p>{{ event.name }}</p>
        </v-card-title>
      </v-img>
    </v-card>
  </div>
</template>

<script>



export default {
  props: ["event"],

  

  methods: {
    redirect() {
      this.$router.push("/details/" + this.event.id);
    },
  },

  
};
</script>

<style scoped>
.event-card {
  text-align: center;
  height: 75%;
  width:95%;

  display: flex;
  align-items: center;
  transition: transform 0.2s;

}

.v-sheet.v-card {
  border: 2px solid rgba(125, 10, 241, 0.625);
  border-radius: 15px;
  
}

.event-card:hover {
  cursor: pointer;
  transform: scale(1.1);
}

.v-card__title {
  justify-content: center;
  margin-top: 4vw;
  color: white;
  font-size:1.5vw;
}

.access {
  background-color: rgba(135, 5, 228, 0.023);
  height: 2.5vh;
  
}

.event-img {
  text-align: center;
  width:30vw;
  
}

@media only screen and (max-width: 670px) {
 .event-img {
  
  width:40vw;
  
}
.v-card__title{
  font-size:4vw;
}
}
@media only screen and (max-width: 560px) {
 .event-img {
  width:60vw;
  
}
}
</style>
