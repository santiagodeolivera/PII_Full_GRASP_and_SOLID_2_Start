//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        // The previous form of this method didn't follow the SRP principle because
        // the way in which the representative text of the recipe is used
        // (whether it's printing in console, or writing to a file, or sending over the Internet)
        // is not related to the recipe itself, so it's modified into a separate responsibility.
        public void PrintRecipe(ITextRedirector textRedirector)
        {
            textRedirector.InsertText("Receta de ");
            textRedirector.InsertText(this.FinalProduct.Description);
            textRedirector.InsertText(":\n");
            foreach (Step step in this.steps)
            {
                textRedirector.Insert(step.Quantity);
                textRedirector.InsertText(" de '");
                textRedirector.InsertText(step.Input.Description);
                textRedirector.InsertText("' usando '");
                textRedirector.InsertText(step.Equipment.Description);
                textRedirector.InsertText("' durante ");
                textRedirector.Insert(step.Time);
                textRedirector.InsertText(" minutos \n");
            }
        }
    }
}