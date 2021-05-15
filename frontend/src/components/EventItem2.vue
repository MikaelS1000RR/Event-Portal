<template>
  <div class="event-card" @click="redirect">
    <v-card :loading="loading" class="mx-auto my-12" >
      <div class="access">
        <p>{{event.access}}</p>
       
      </div>
      <v-img class="event-img" height="300px" :src="event.imgUrl">
      
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
  width:85%;
 margin-left:6vw !important;
  display: flex;
  align-items: center;
  transition: transform 0.2s;

}

.v-sheet.v-card {
  border-radius: 0px;
  
}

.event-card:hover {
  cursor: pointer;
  
}

.v-card__title {
  justify-content: center;
  margin-top: 4vw;
  color: white;
  font-size:1.5vw;
}

.access {
  background-color: white;
  height: 3.5vh;
  color:black;
  
}

.event-img {
  text-align: center;
  width:100%;

  
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