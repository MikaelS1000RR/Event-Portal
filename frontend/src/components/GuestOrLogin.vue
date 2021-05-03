<template>
  <div class="form-grid-container">
   
    <v-app>
<div class="grid">


     <v-card width="500px" class="mt-5 mx-a">
         <v-card-title class="pb-0">
          <h1>Join as Guest</h1>
          <v-card-text>
         <v-form @submit.prevent="pressed">
           <v-text-field 
  
           label="Username" 
           prepend-icon="mdi-account-circle"
           />
               </v-form>
              </v-card-text>
              <v-divider></v-divider>
            </v-card-title>
            </v-card>



  
</div>
  </v-app>
    </div>
       

</template>

<script>
export default {

  

}
</script>

<style scoped>


.grid {
 
display: grid;
  justify-items: center;
  align-items: center;
 grid-template-columns: 1fr;
  grid-template-rows: 70vh;


}


</style>