//// Problem: You dont know what kind of Products the Crator class will need

abstract class Product { }
class ConcreteProduct1 : Product { }
//...
class ConcreteProductN : Product { }


abstract class Creator {
  abstract public Product FactoryMethod();
  public void AnOperation() {
    //...
    var product = FactoryMethod();
    //...
  }
}
class ConcreteCreator1 : Creator {
  override public Product FactoryMethod() {
    return new ConcreteProduct1();
  }
}
//...
class ConcreteCreatorN : Creator {
  override public Product FactoryMethod() {
    return new ConcreteProductN();
  }
}

// class Use {
//   static void Main() {
//     Creator[] creators = [new ConcreteCreator1(), new ConcreteCreatorN()];

//     foreach (Creator creator in creators) {
//       Product product = creator.FactoryMethod();
//       Console.WriteLine($"Created {product.GetType().Name}");
//     }
//   }
// }
//------------------------------------------------//

//Problem: The document will be out of pages but I don't know what pages I will need

// abstract class Page { }
// class EducationPage : Page { }
// class Skillspage : Page { }
// class ExperincePage : Page { }
// class IntroductionPage : Page { }
// class ResultsPage : Page { }
// class ConclusionPage : Page { }
// class SummaryPage : Page { }
// class BibliographyPage : Page { }


// abstract class Document {
//   private List<Page> pages = new List<Page>();
//   public List<Page> Pages => pages;

//   public Document() {
//     CreatePages();
//   }

//   public abstract void CreatePages();
// }
// class Resume : Document {
//   public override void CreatePages() {
//     Pages.Add(new Skillspage());
//     Pages.Add(new EducationPage());
//     Pages.Add(new ExperincePage());
//   }
// }
// class Report : Document {
//   public override void CreatePages() {
//     Pages.Add(new IntroductionPage());
//     Pages.Add(new ResultsPage());
//     Pages.Add(new ConclusionPage());
//     Pages.Add(new SummaryPage());
//     Pages.Add(new BibliographyPage());
//   }
// }

// // class Example {
// //   static void Main() {
// //     Document[] documents = [new Resume(), new Report()];

// //     foreach (Document doc in documents) {
// //       Console.WriteLine("\n" + doc.GetType().Name + "--");
// //       foreach (Page page in doc.Pages) {
// //         Console.WriteLine(" " + page.GetType().Name);
// //       }
// //     }
// //   }
// // }
