<template>
  
  <div class="vue-tempalte">
   

    <v-app>
       <v-card width="400px" class="mt-5 mx-a">
         <v-card-title class="pb-0">
        <h1>Login</h1>
         </v-card-title>
         <v-card-text>
         <v-form>
           <v-text-field 
           label="Username" 
           prepend-icon="mdi-account-circle"
           />
           <v-text-field
           type="Password"
           label="Password"
           prepend-icon="mdi-lock"
           append-icon="mdi-eye-off"
           />
         </v-form>
         </v-card-text>
         <v-divider></v-divider>
         <v-card-actions>
         <v-btn color=success>Register</v-btn>
         <v-spacer></v-spacer>
         <v-btn color="info">Login</v-btn>
         </v-card-actions>
    </v-card>
  </v-app>

       
    </div>

</template>

<script>

</script>

<style scoped>








</style>