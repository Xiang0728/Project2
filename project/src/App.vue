<template>
  <v-app>
   <v-breadcrumbs
      :items="items"
      large
    ></v-breadcrumbs>

    <v-main>
      <router-view/>
    </v-main>

   

     <v-footer
      padless dark>   
       <v-col
      class="indigo lighten-1 text-center white--text"
      cols="12"
        >
      {{ new Date().getFullYear() }} — <strong>Project2</strong>
    </v-col>
    </v-footer>

  </v-app>
</template>




<script>

export default {
  name: 'App',

  data: () => ({
    items: [        
        {
          text: '首頁',         
          href: 'Home',
        },
        {
          text: '發送紀錄',
         
          href: 'MailList',
        },
      ],
  }),
};
</script>
